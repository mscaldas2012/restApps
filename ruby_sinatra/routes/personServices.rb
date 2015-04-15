set :port, 8080

before do
    headers "Content-Type" => "application/json; charset=utf8"
end

AllAccounts = Array.new

get '/testAPI/account' do
  name = params[:name]
  if name.nil?
     AllAccounts.to_json
  else
    t = AllAccounts.select { |p| p.name.include? name }	
    t.to_json
  end
end

get '/testAPI/account/:id' do
  t = AllAccounts.select { |p| p.id.to_i == (params[:id].to_i) }
  if t.nil? or t.size < 1
    halt 404
  end
  t.to_json
end

post '/testAPI/account' do
  body = JSON.parse request.body.read
  if body.nil? or !body.has_key?('name')
        m = Message.new('name is a required attribute when creating an accout',"REQ_FIELD_NAME")
	body(m.to_json)
	halt 400
  end
  t = Person.new(body['name'],body['age'])
  t.id = AllAccounts.size  
  if !body['bookmarks'].nil?
    body['bookmarks'].each do |b|
      bm = Bookmark.new(b['url'], b['description'])   
      t.bookmarks.push(bm)
      sleep(1)
    end
  end
  AllAccounts.push(t)
  status 200
  t.to_json 
end

put '/testAPI/account/:id' do
  body = JSON.parse request.body.read
  t = AllAccounts.select { |p| p.id.to_i == (params[:id].to_i) }
  if t.nil? or t.size < 1
    halt 404
  end
  t = t[0]
  t.name = body['name']
  t.age = body['age']
  t.to_json
end

delete '/testAPI/account/:id' do
  t = AllAccounts.select { |p| p.id.to_i == (params[:id].to_i) }
  if t.nil? or t.size < 1
    halt 404
  end
  AllAccounts.delete(t[0])
  halt 200
end


get '/testAPI/account/:userId/bookmark' do
   owner = AllAccounts.select { |p| p.id.to_i == (params[:userId].to_i) }
   if owner.nil? or owner.size < 1
 	halt 404
   end
   owner[0].bookmarks.to_json	
end

post '/testAPI/account/:userId/bookmark' do
   body = JSON.parse request.body.read
   owner = AllAccounts.select { |p| p.id.to_i == (params[:userId].to_i) }
   if owner.nil? or owner.size < 1
 	halt 404
   end
   b = Bookmark.new( body['url'], body['description'])
   owner[0].bookmarks.push(b)
   b.to_json
end 

put '/testAPI/account/:userId/bookmark/:bId' do
   body = JSON.parse request.body.read
   owner = AllAccounts.select { |p| p.id.to_i == (params[:userId].to_i) }
   if owner.nil? or owner.size < 1
 	halt 404
   end
   bookmark = owner[0].bookmarks.select { |b| b.id.to_i == (params[:bId].to_i) }
   if bookmark.nil? or bookmark.size <1
 	halt 404
   end
   bookmark = bookmark[0]
   bookmark.url = body['url']
   bookmark.description = body['description']
   bookmark.to_json
end

delete '/testAPI/account/:userId/bookmark/:bId' do
   owner = AllAccounts.select { |p| p.id.to_i == (params[:userId].to_i) }
   if owner.nil? or owner.size < 1
 	halt 404
   end
   bookmark = owner[0].bookmarks.select { |b| b.id.to_i == (params[:bId].to_i) }
   if bookmark.nil? or bookmark.size <1
 	halt 404
   end
   owner[0].bookmarks.delete(bookmark[0])
   halt 200
end
