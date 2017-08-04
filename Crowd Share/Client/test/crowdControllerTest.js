(function () {
    describe('#LocalStorageFunction', function () {
        describe('#isLogin function', function () {
            it('when is login must be true', function () {
                var c = new Controller('sumurl');
                var actual = c.isLoggedIn();
                var expected = localStorage.getItem('sessionKey') != null; // must be undefined
                expect(actual).to.equal(expected);
            });
        });
        describe('#getUserKey function', function () {
            it('when is login must return the key ', function () {
                var c = new Controller('sumurl');
                var actual = c.getUserKey();
                var expected = localStorage.getItem('sessionKey');; // must be undefined
                expect(actual).to.equal(expected);
            });
        });
        describe('#getUsername function', function () {
            it('when is login must return the name', function () {
                var c = new Controller('sumurl');
                var actual = c.getUsername();
                var expected = localStorage.getItem('username'); // must be undefined
                expect(actual).to.equal(expected);
            });
        });
    });
}());