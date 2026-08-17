module FortePayments
  class Client
    module Transaction

      def create_transaction(options = {})
        post("/transactions", options) 
      end

      def list_transactions(options = {})
        get("/transactions", options)
      end

      def find_transaction(transaction_id)
        get("/transactions/#{transaction_id}")
      end

      def update_transaction(transaction_id, options = {})
        put("/transactions/#{transaction_id}", options)
      end

    end
  end
end
