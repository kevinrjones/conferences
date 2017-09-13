

test("Callback is called", function(){
    var callback = sinon.spy();
    sinon.stub(jQuery, "ajax").yieldsTo("success", [1, 2, 3]);

    blogPosts.getPosts(callback);
    ok(callback.called, "Callback was called");

    ok(jQuery.ajax.calledWithMatch({foo: 'bar', url: "/blog/posts"}))
    ok(callback.calledWith([1,2,3]))
})

