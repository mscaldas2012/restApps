class Person 
  include MyJson

  attr_accessor :id, :name, :age, :bookmarks

  def initialize()
    @bookmarks = Array.new
  end

  def initialize(name, age)
    @name = name
    @age = age
    @bookmarks = Array.new
  end


#  property :bookmarks,  Bookmark
end
