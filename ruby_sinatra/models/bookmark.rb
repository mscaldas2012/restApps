class Bookmark
  include MyJson

  attr_accessor :id, :url, :description

  def inititialize()
    id = Time.now.to_i
  end

  def initialize(url, description )
    @id = Time.now.to_i
    @url = url
    @description = description
  end

end

