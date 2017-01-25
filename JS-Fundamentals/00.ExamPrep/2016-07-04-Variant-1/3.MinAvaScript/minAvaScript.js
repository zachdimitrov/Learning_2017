function solve(args) {
    let rules = [],
        globalPr = 0,
        masterPr = 0,
        localPr = 0,
        singlePr = 0,
        selector,
        value,
        property,
        priority,
        inProp = false;

    for (const i in args) {
        let line = args[i].trim();
        //console.log(spline);
        if (line.indexOf('@') === 0) {
            if (!inProp) {
                globalPr = line.slice(1);
                localPr = globalPr;
                masterPr = localPr;
                singlePr = masterPr;
                //console.log(globalPr);
            } else {
                masterPr = line.slice(1);
                singlePr = masterPr;
            }
        }
        if (line.indexOf('{') >= 0) {
            inProp = true;
            let ind, prop;
            localPr = globalPr;
            if (line.indexOf('@') >= 0) {
                ind = line.indexOf('@');
                let pr = +line.split('@')[line.split('@').length - 1];
                //console.log(pr);
                localPr = pr;
                masterPr = localPr;
                singlePr = masterPr;
            }
            sel = line.split('{').filter(a => a !== ' ')[0].trim();
            //console.log(sel);
            selector = sel;
        }
        if (line.indexOf(':') >= 0) {
            let text = line.split(':').map(a => a.trim());
            //console.log(text);
            property = text[0];
            singlePr = masterPr;
            if (text[text.length - 1].indexOf('@') >= 0) {
                let divided = text[text.length - 1].split(' ');
                singlePr = +divided[1].slice(1);
                //console.log(singlePr);
                value = divided[0];
            } else {
                value = text[text.length - 1];
            }
            priority = singlePr;
            if (property) {
                rules.push([
                    selector, property, value, priority
                ]);
            }
        }
        if (line.trim() === '}') {
            inProp = false;
            //globalPr = 0;
            localPr = globalPr;
            masterPr = localPr;
            singlePr = masterPr;
        }
    }
    //console.log(rules);
    let result = [],
        rest;
    while (true) {
        let correct = rules[0];

        rest = rules.slice(1);

        for (let j = 0; j < rest.length; j++) {
            if (rest[j][0] === correct[0] && rest[j][1] === correct[1]) {
                if (rest[j][3] > correct[3]) {
                    correct = rest[j];
                }
                rest.splice(j, 1);
                j--;
            }

        }
        result.push(correct);
        if (rest.length === 0) {
            break;
        }
        rules = rest;
    }
    result = result.sort();
    //console.log(result);
    for (let r in result) {
        console.log(`${result[r][0]} { ${result[r][1]}: ${result[r][2]} }`);
    }
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