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
    // once before all tests in this describe
    before(() => {
        console.log('--- before all ---');
    });

    // once after all tests in this describe
    after(() => {
        console.log('--- after all ---');
    });

    // once before every test in this describe
    beforeEach(() => {
        console.log('- before each -');
    });

    // once after every test in this describe
    afterEach(() => {
        console.log('- after each -');
    });

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