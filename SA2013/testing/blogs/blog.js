var blogPosts = function() {
    getPosts = function (callback) {
        $.ajax({
            url: '/blog/posts',
            foo: 'bar',
            success: function(data){
                callback(data);
            }
        });
    }
    return {
        getPosts: getPosts
    }
}();
