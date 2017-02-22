function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!',
        INVALID_ALIGNMENT: 'alignment must be string with one of these values: "good, neutral, evil"'
    };

    const validate = {
        ifNameIsCorrect: function(name) {
            if (typeof name !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
            if (name.length < 2 || name.length > 20) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
            if (name.match(/[^a-zA-Z ]/)) {
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        ifNumberIsAboveZero: function(n) {
            if (typeof n !== 'number' || n < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        ifalignmentIsCorrect: function(val) {
            if (typeof val !== 'string' || (val !== 'good' && val !== 'neutral' && val !== 'evil')) {
                throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
            }
        },
        ifDamageIsCorrect: function(dam) {
            if (typeof dam !== 'number' || dam < 0 || dam > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        ifHealthIsCorrect: function(h) {
            if (typeof h !== 'number' || h < 0 || h > 200) {
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        ifCountIsCorrect: function(c) {
            if (typeof c !== 'number' || c < 0) {
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }
        },
        ifSpeedIsCorrect: function(s) {
            if (typeof s !== 'number' || s < 0 || s > 100) {
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }
        },
        ifIsAULike: function(au) {
            ['name', 'alignment', 'damage', 'health', 'count', 'speed'].forEach(function(key) {
                if (!au.hasOwnProperty(key)) {
                    throw new Error('Battle participants must be ArmyUnit-like!');
                }
            });
        }
    }

    let getId = (function() {
        let id = 0;
        return function() {
            id++;
            return id;
        };
    }());

    // your implementation goes here

    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifNameIsCorrect(val);
            this._name = val;
        }

        get manaCost() {
            return this._manaCost;
        }

        set manaCost(val) {
            validate.ifNumberIsAboveZero(val);
            this._manaCost = val;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }

        set name(val) {
            validate.ifNameIsCorrect(val);
            this._name = val;
        }

        get alignment() {
            return this._alignment;
        }

        set alignment(val) {
            validate.ifalignmentIsCorrect(val);
            this._alignment = val;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
            this.id = getId();
        }

        get damage() {
            return this._damage;
        }

        set damage(val) {
            validate.ifDamageIsCorrect(val);
            this._damage = val;
        }

        get health() {
            return this._health;
        }

        set health(val) {
            validate.ifHealthIsCorrect(val);
            this._health = val;
        }

        get count() {
            return this._count;
        }

        set count(val) {
            validate.ifCountIsCorrect(val);
            this._count = val;
        }

        get speed() {
            return this._speed;
        }

        set speed(val) {
            validate.ifSpeedIsCorrect(val);
            this._speed = val;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana) {
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana() {
            return this._mana;
        }

        set mana(val) {
            validate.ifNumberIsAboveZero(val);
            this._mana = val;
        }
    }

    class Battlemanager {
        constructor() {
            this.commanders = [];
        }

        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        }

        getArmyUnit(options) {
            return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed)
        }

        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }

        addCommanders(...comm) {
            for (let c in comm) {
                this.commanders.push(comm[c]);
            }
            return this;
        }

        addArmyUnitTo(commanderName, armyUnit) {
            this.commanders.find(c => c.name === commanderName).army.push(armyUnit);
            return this;
        }

        addSpellsTo(commanderName, ...spellsToAdd) {
            for (let s of spellsToAdd) {
                this.commanders.find(c => c.name === commanderName).spellbook.push(s);
            }
            return this;
        }

        findCommanders(query) {
            let found = this.commanders.filter(function(c) {
                for (let key of Object.keys(query)) {
                    if (query[key] !== c[key]) {
                        return false;
                    }
                }
                return true;
            });

            return found
                .sort(function(a, b) {
                    var nameA = a.name.toUpperCase(); // ignore upper and lowercase
                    var nameB = b.name.toUpperCase(); // ignore upper and lowercase
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }
                    // names must be equal
                    return 0;
                });
        }

        findArmyUnitById(id) {
            for (c of this.commanders) {
                for (let au of c.army) {
                    if (au.id === id) {
                        return au;
                    }
                }
            }
        }

        findArmyUnits(query) {
            let found = [];
            for (let c of this.commanders) {
                for (let au of c.army) {
                    let isFound = true;
                    for (let key in Object.keys(query)) {
                        if (query[key] !== au[key]) {
                            found = false;
                        }
                    }
                    if (isFound) {
                        found.push(au);
                    }
                }
            }
            return found.sort(function(a, b) {
                if (a.speed === b.speed) {
                    var nameA = a.name.toUpperCase(); // ignore upper and lowercase
                    var nameB = b.name.toUpperCase(); // ignore upper and lowercase
                    if (nameA < nameB) {
                        return -1;
                    }
                    if (nameA > nameB) {
                        return 1;
                    }
                    // names must be equal
                    return 0;
                } else {
                    return b.speed - a.speed
                }
            });
        }

        spellcast(casterName, spellName, targetUnitId) {
            let caster = this.commanders.find(c => c.name === casterName);
            if (caster === undefined) {
                throw new Error(`Cannot cast with non-existant commander ${casterName}`);
            }
            let spell = caster.spellbook.find(s => s.name === spellName);
            if (spell === undefined) {
                throw new Error(`${casterName} does not know ${spellName}`);
            }
            if (caster.mana < spell.manaCost) {
                throw new Error('Not enough mana!');
            }
            let armyUnit;
            for (let c of this.commanders) {
                armyUnit = c.army.find(au => au.id === targetUnitId);
            }
            if (armyUnit === undefined) {
                throw new Error('Target not found!');
            }

            commander.mana -= spell.manaCost;
            return this;
        }

        battle(attacker, defender) {
            validate.ifIsAULike(attacker);
            validate.ifIsAULike(defender);
            let attackerTotalDamage = attacker.damage * attacker.count;
            let defenderTotalHealth = defender.health * defender.count - attackerTotalDamage;
            defender.count = Math.ceil(defenderTotalHealth / defender.health);
            return this;
        }
    }

    return new Battlemanager();
}

module.exports = solve;

let MANAGER = solve();

const commanders = [
    { name: 'Tinky Winky', alignment: 'good', mana: 5 },
    { name: 'xxx', alignment: 'good', mana: 10 },
    { name: 'Bill Gates', alignment: 'evil', mana: 5 },
].map(c => MANAGER.getCommander(c.name, c.alignment, c.mana))

MANAGER.addCommanders(...commanders)
console.log(MANAGER.commanders);
console.log('---------------------')
commanders.forEach(function(c) {
    console.log(MANAGER.findCommanders({ name: c.name, alignment: c.alignment })[0]);
});