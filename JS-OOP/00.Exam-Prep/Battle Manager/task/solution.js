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
        INVALID_ALIGNMENT: 'Alignment must be good, neutral or evil!'
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
        ifSpellIsCorrect: function(name) {
            if (typeof name !== 'string') {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
            if (name.length < 2 || name.length > 20) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
            if (name.match(/[^a-zA-Z ]/)) {
                throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
            }
        },
        ifNumberIsAboveZero: function(n) {
            if (typeof n !== 'number' || n <= 0 || n !== (n | 0)) {
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
            ['_name', '_alignment', '_damage', '_health', '_count', '_speed'].forEach(function(key) {
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

        get effect() {
            return this._effect;
        }

        set effect(val) {
            if (typeof val !== 'function' || val.length !== 1) {
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
            this._effect = val;
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
            let spells = [];
            for (let s of spellsToAdd) {
                let spell;
                try {
                    spell = new Spell(s.name, s.manaCost, s.effect);
                } catch (e) {
                    throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }

                if (spell) {
                    spells.push(spell);
                } else {
                    throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }
            }
            for (let s of spells) {
                this.findCommanders({ name: commanderName })[0].spellbook.push(s);
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
            for (let c of this.commanders) {
                for (let au of c.army) {
                    if (au.id === id) {
                        return au;
                    }
                }
            }
        }

        findArmyUnits(query) {
            let found = [];
            let com = this.commanders;
            for (let c in com) {
                let army = com[c].army;
                for (let au in army) {
                    let isFound = true;
                    for (let key of Object.keys(query)) {
                        if (query[key] !== army[au][key]) {
                            isFound = false;
                        }
                    }
                    if (isFound) {
                        found.push(army[au]);
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
                    return b.speed - a.speed;
                }
            });
        }

        spellcast(casterName, spellName, targetUnitId) {
            let caster = this.findCommanders({ name: casterName })[0];
            if (caster === undefined) {
                throw new Error('Can\'t cast with non-existant commander ' + casterName + '!');
            }
            let spell = caster.spellbook.find(s => s.name === spellName);
            if (spell === undefined) {
                throw new Error(casterName + ' doesn\'t know ' + spellName + '!');
            }
            if (caster.mana < spell.manaCost) {
                throw new Error('Not enough mana!');
            }
            let armyUnit = this.findArmyUnitById(targetUnitId);
            if (armyUnit === undefined) {
                throw new Error('Target not found!');
            }
            spell.effect(armyUnit);
            caster.mana -= spell.manaCost;
            return this;
        }

        battle(attacker, defender) {
            validate.ifIsAULike(attacker);
            validate.ifIsAULike(defender);
            let attackerTotalDamage = attacker.damage * attacker.count;
            let defenderTotalHealth = defender.health * defender.count - attackerTotalDamage;
            let c = Math.ceil(defenderTotalHealth / defender.health);
            defender.count = c < 0 ? 0 : c;
            return this;
        }
    }

    return new Battlemanager;
}

module.exports = solve;

/*
let MANAGER = solve();

const tinkyWinky = MANAGER.getCommander('Tinky Winky', 'good', 66),
    billGates = MANAGER.getCommander('Bill Gates', 'evil', 66);

MANAGER.addCommanders(tinkyWinky, billGates);

const armyUnits = {
    dwarfs: MANAGER.getArmyUnit({ name: 'Dwarfs', speed: 20, damage: 33, health: 44, alignment: 'good', count: 50 }),
    codeMonkeys: MANAGER.getArmyUnit({ name: 'Code Monkeys', speed: 20, damage: 5, health: 5, alignment: 'good', count: 300 }),
    students: MANAGER.getArmyUnit({ name: 'Students', speed: 20, damage: 25, health: 33, alignment: 'good', count: 100 }),
    mages1: MANAGER.getArmyUnit({ name: 'Mages One', speed: 15, damage: 60, health: 25, alignment: 'good', count: 5 }),
    mages2: MANAGER.getArmyUnit({ name: 'Mages Two', speed: 15, damage: 60, health: 25, alignment: 'good', count: 50 }),
    mages3: MANAGER.getArmyUnit({ name: 'Mages Three', speed: 15, damage: 60, health: 25, alignment: 'good', count: 3 }),
};

MANAGER
    .addArmyUnitTo('Tinky Winky', armyUnits.dwarfs)
    .addArmyUnitTo('Bill Gates', armyUnits.codeMonkeys)
    .addArmyUnitTo('Bill Gates', armyUnits.students)
    .addArmyUnitTo('Bill Gates', armyUnits.mages1)
    .addArmyUnitTo('Tinky Winky', armyUnits.mages2)
    .addArmyUnitTo('Bill Gates', armyUnits.mages3);

console.log(MANAGER.findArmyUnits({}));
*/