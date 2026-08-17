require 'faraday'
require 'faraday_middleware'

Dir[File.expand_path('../resources/*.rb', __FILE__)].each{|f| require f}

module FortePayments
  class Client
    include FortePayments::Client::Address
    include FortePayments::Client::Customer
    include FortePayments::Client::Paymethod
    include FortePayments::Client::Settlement
    include FortePayments::Client::Transaction

    attr_reader :api_key, :secure_key, :organization_id, :location_id, :auth_organization_id

    def initialize(api_key:, secure_key:, organization_id:, location_id:, auth_organization_id: nil)
      @api_key     = api_key
      @secure_key  = secure_key
      @organization_id = organization_id
      @location_id = location_id
      @auth_organization_id = auth_organization_id || organization_id
    end

    def get(path, options={})
      connection.get("#{base_path}#{path}", options).body
    end

    def post(path, req_body)
      connection.post do |req|
        req.url("#{base_path}#{path}")
        req.body = req_body
      end.body
    end

    def put(path, options={})
      connection.put("#{base_path}#{path}", options).body
    end

    def delete(path, options = {})
      connection.delete("#{base_path}#{path}", options).body
    end

    private

    def base_url
      "https://sandbox.forte.net"
    end

    def base_path
      "/api/v3/organizations/#{organization_id}/locations/#{location_id}"
    end

    def connection
      Faraday.new(url: base_url, headers: { :accept => 'application/json', 'X-Forte-Auth-Organization-Id' => "#{auth_organization_id}" }) do |connection|
        connection.basic_auth api_key, secure_key
        connection.request    :json
        connection.response   :logger
        connection.use        FaradayMiddleware::Mashify
        connection.response   :json
        connection.adapter    Faraday.default_adapter
      end
    end
  end
end
