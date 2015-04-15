class Message
	include MyJson

   attr_accessor :message, :code

   def initialize(msg, code)
      @message= msg
      @code = code
   end

end

