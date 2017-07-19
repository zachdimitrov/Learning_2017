const { expect } = require('chai');

const getValueAfter = (value, seconds) => {
    return new Promise((resolve) => {
        return setTimeout(() => {
            resolve(value);
        }, seconds * 1000);
    });
};

describe('Async tests', () => {
    it('with done()', (done) => {
        getValueAfter(5, 1)
            .then((value) => {
                expect(value).to.equal(5);
                done();
            });
    });

    it('with return promise', () => {
        return getValueAfter(5, 1)
            .then((value) => {
                expect(value).to.equal(5);
            });
    });

    it('no function', () => {
        expect(5).not.to.be.null;
    });
});

describe.skip('Skipped', () => {
    // test
});

describe('Test sums', () => {
    // test 1
    it('should return 4', () => {
        // arrange
        const x = 2;
        const y = 2;

        //act
        const expected = x + y;

        // assert
        expect(expected).to.eq(4);
    });

    // test 2
    it('should return 8', () => {
        // arrange
        const x = 4;
        const y = 4;

        //act
        const expected = x + y;

        // assert
        expect(expected).to.eq(8);
    });
});