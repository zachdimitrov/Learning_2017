const { expect } = require('chai');
const sinon = require('sinon');

const BaseData = require('../../../data/base/base.data');

describe('Base Data getAll()', () => {
    const db = { collection: () => {} };
    let ModelClass = null;
    const validator = null;
    let data = null;

    let items = [];
    const toArray = () => {
        return Promise.resolve(items);
    };
    const find = () => {
        return { toArray };
    };

    describe('when there are items in db', () => {
        describe('with default toViewModel', () => {
            beforeEach(() => {
                items = ['item one', 'item two', 'item three'];
                sinon.stub(db, 'collection').callsFake(() => {
                    return { find };
                });
                ModelClass = class Test {};
                data = new BaseData(db, ModelClass, validator);
            });

            afterEach(() => {
                db.collection.restore();
            });

            it('expect to return items', () => {
                return data.getAll()
                    .then((models) => {
                        expect(models).to.deep.equal(items);
                    });
            });
        });
    });
});

// https://www.youtube.com/watch?v=HKMlLdcuyBE
// 00:31:17
