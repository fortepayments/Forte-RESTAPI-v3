module FortePayments
  class Client
    module Paymethod

      def create_paymethod(options = {})
        post("/paymethods", options)
      end

      def list_paymethods(options = {})
        get("/paymethods", options)
      end

      def find_paymethod(paymethod_id)
        get("/paymethods/#{paymethod_id}")
      end

      def update_paymethod(paymethod_id, options = {})
        put("/paymethods/#{paymethod_id}", options)
      end

      def delete_paymethod(paymethod_id)
        delete("/paymethods/#{paymethod_id}")
      end

    end
  end
end
