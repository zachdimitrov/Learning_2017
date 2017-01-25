function solve(args) {
    let globalPr = 0;
    let localPr = 0;
    let inSelector = false;
    let bindings = {};
    let selectorRef;

    args.forEach(function(line) {
        line = line.trim();
        if (line[0] === '@') {
            const newPriority = +line.substring(1).trim();
            if (inSelector) {
                localPr = newPriority;
            } else {
                globalPr = newPriority;
            }
        } else if (line[0] === '}') {
            inSelector = false;
        } else {
            let braceIn = line.indexOf('{');
            if (braceIn < 0) {
                const spl = line.split(/[:;]/g);
                const property = spl[0].trim();
                const value = spl[1].trim();
                let currentPriority = localPr;
                const klIndex = spl[2].indexOf('@');
                if (klIndex >= 0) {
                    currentPriority = +spl[2].substring(klIndex + 1).trim();
                }
                if (!selectorRef.hasOwnProperty(property)) {
                    selectorRef[property] = {
                        value: value,
                        priority: currentPriority
                    };
                } else {
                    const obj = selectorRef[property];
                    if (obj.priority < currentPriority) {
                        obj.value = value;
                        obj.priority = currentPriority;
                    }
                }
            } else {
                inSelector = true;
                const selectorName = line.substring(0, braceIn).trim();
                localPr = globalPr;
                if (!bindings.hasOwnProperty(selectorName)) {
                    bindings[selectorName] = {};
                }
                selectorRef = bindings[selectorName];

                const kliombaIn = line.indexOf('@', braceIn);
                if (kliombaIn >= 0) {
                    localPr = +line.substring(kliombaIn + 1).trim();
                }
            }
        }
    });

    let result = [];
    for (let selector in bindings) {
        selectorRef = bindings[selector];
        for (let property in selectorRef) {
            const value = selectorRef[property].value;
            const line = `${selector} { ${property}: ${value}; }`
            result.push(line);
        }
    }
    console.log(result.sort().join('\n'));
}

//tests

console.log('- TEST 1 -');
solve([
    'li {',
    '    font-size: 2px;',
    '    font-weight: bold;',
    '}',
    'div {',
    '    font-size: 20px; @5',
    '}',
    'div { @4',
    '    font-size: 17px;',
    '}',
    '@19',
    'li {',
    '    font-size: 42px;',
    '    color: red; @9',
    '}'
]);
console.log('--------- output ---------');
console.log(`div { font-size: 20px; }
li { color: red; }
li { font-size: 42px; }
li { font-weight: bold; }`);
console.log('- TEST 2 -');
solve([
    'enthusiasm { @5',
    '  ap-percept-ion:buying;',
    '  @2',
    '  houston:pZ!X;',
    '  chute-s:accelerometers;',
    '}',
    '@9',
    'molar { @6',
    '  @15',
    '  houston:E!NVDt; @7',
    '  houston:u#It#;',
    '  ap-percept-ion:Dog; @15',
    '  chute-s:advises;',
    '}',
    'oodles {',
    '  @13',
    '  chute-s:perish;',
    '}',
    'molar {',
    '  r-ega-rding:4lXPE;',
    '  r-ega-rding:digesting;',
    '  houston:xZAEIh#S;',
    '  chute-s:benched;',
    '  @3',
    '  ap-percept-ion:gssO%FDd;',
    '}',
    'enthusiasm { @15',
    '  houston:NkR99XZ;',
    '  ap-percept-ion:aPQG;',
    '}'
]);
console.log('--------- output ---------');
console.log(`enthusiasm { ap-percept-ion: aPQG; }
enthusiasm { chute-s: accelerometers; }
enthusiasm { houston: NkR99XZ; }
molar { ap-percept-ion: Dog; }
molar { chute-s: advises; }
molar { houston: u#It#; }
molar { r-ega-rding: 4lXPE; }
oodles { chute-s: perish; }`);

console.log('- TEST 3 -');
solve([
    'horse{',
    'ab-sent-ing:grey;',
    '}',
    'harrison{',
    'adj-o-urns:EWQ1uHI;',
    'ab-sent-ing:prosecute;',
    'adj-o-urns:_TLty8;',
    'ab-sent-ing:JYIw;',
    'un-responsi-ve:majority;',
    'ab-sent-ing:radiantly;',
    '}',
    'prop{',
    'a-lka-ne:belay;',
    'p-r-imate:SY9;',
    'adj-o-urns:ribs;',
    '}',
    'inhaled{',
    'bulkhead:62vQ_jbi;',
    'p-r-imate:resurrections;',
    'p-r-imate:gripes;',
    'm-otorcars:GFV*;',
    '}',
    'domes{',
    'bulkhead:ambulances;',
    '}',
    'bureaus{',
    'adj-o-urns:+HLZp1K;',
    'bulkhead:l_t_SQhY;',
    'm-otorcars:7kzEb;',
    'm-otorcars:knockdown;',
    'bulkhead:5*uZ+w9;',
    'ab-sent-ing:gluey;',
    '}',
    'raptly{',
    'm-otorcars:vice;',
    '}',
    'jaws{',
    'e-x-pose:untidiness;',
    'm-otorcars:prepared;',
    'a-lka-ne:7EE#OC;',
    'un-responsi-ve:emotion;',
    'ab-sent-ing:4Mb;',
    'un-responsi-ve:armageddon;',
    '}',
    'domes{',
    'bulkhead:streak;',
    'a-lka-ne:bp7;',
    'ab-sent-ing:6m;',
    'adj-o-urns:attuning;',
    'bulkhead:6RNu_wjq;',
    '}',
    'jaws{',
    'un-responsi-ve:I!iB;',
    'm-otorcars:optoacoustic;',
    'p-r-imate:surly;',
    'un-responsi-ve:residence;',
    'bulkhead:inventive;',
    'ab-sent-ing:muggers;',
    'ab-sent-ing:sheep;',
    '}',
    'inhaled{',
    'a-lka-ne:Yf0OGR4N;',
    'un-responsi-ve:menzies;',
    'p-r-imate:nexus6;',
    '}',
    'capecod{',
    'adj-o-urns:8j&NkNl;',
    'm-otorcars:FueMFib;',
    'e-x-pose:UuRhOb;',
    'un-responsi-ve:I4;',
    'e-x-pose:outlook;',
    'e-x-pose:m2wMiJ;',
    '}',
    'evenness{',
    'ab-sent-ing:d*pSoZY4;',
    'adj-o-urns:gTMNil;',
    '}',
    'capecod{',
    'un-responsi-ve:%BC;',
    'bulkhead:bloc;',
    'p-r-imate:culled;',
    'm-otorcars:drummers;',
    'm-otorcars:catchword;',
    'bulkhead:NKN;',
    'un-responsi-ve:GfX%_;',
    '}',
    'evenness{',
    'adj-o-urns:attachers;',
    'm-otorcars:leachate;',
    'a-lka-ne:22T2x45;',
    'm-otorcars:qa_#;',
    'bulkhead:QH;',
    'a-lka-ne:adjectives;',
    'p-r-imate:F0jG;',
    '}'
]);
console.log('------- output -------');
console.log(`bureaus { ab-sent-ing: gluey; }
bureaus { adj-o-urns: +HLZp1K; }
bureaus { bulkhead: l_t_SQhY; }
bureaus { m-otorcars: 7kzEb; }
capecod { adj-o-urns: 8j&NkNl; }
capecod { bulkhead: bloc; }
capecod { e-x-pose: UuRhOb; }
capecod { m-otorcars: FueMFib; }
capecod { p-r-imate: culled; }
capecod { un-responsi-ve: I4; }
domes { a-lka-ne: bp7; }
domes { ab-sent-ing: 6m; }
domes { adj-o-urns: attuning; }
domes { bulkhead: ambulances; }
evenness { a-lka-ne: 22T2x45; }
evenness { ab-sent-ing: d*pSoZY4; }
evenness { adj-o-urns: gTMNil; }
evenness { bulkhead: QH; }
evenness { m-otorcars: leachate; }
evenness { p-r-imate: F0jG; }
harrison { ab-sent-ing: prosecute; }
harrison { adj-o-urns: EWQ1uHI; }
harrison { un-responsi-ve: majority; }
horse { ab-sent-ing: grey; }
inhaled { a-lka-ne: Yf0OGR4N; }
inhaled { bulkhead: 62vQ_jbi; }
inhaled { m-otorcars: GFV*; }
inhaled { p-r-imate: resurrections; }
inhaled { un-responsi-ve: menzies; }
jaws { a-lka-ne: 7EE#OC; }
jaws { ab-sent-ing: 4Mb; }
jaws { bulkhead: inventive; }
jaws { e-x-pose: untidiness; }
jaws { m-otorcars: prepared; }
jaws { p-r-imate: surly; }
jaws { un-responsi-ve: emotion; }
prop { a-lka-ne: belay; }
prop { adj-o-urns: ribs; }
prop { p-r-imate: SY9; }
raptly { m-otorcars: vice; }
`);