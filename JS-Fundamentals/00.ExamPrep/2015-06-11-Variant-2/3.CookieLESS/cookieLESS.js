function solve(args) {
    let props = {},
        set = {},
        rules = [],
        nested = [],
        propInLine = '',
        result = '';

    for (let i = 0, len = args.length; i < len; i += 1) {
        let line = args[i].trim();
        let openCurly = line.indexOf('{');
        let closedCurly = line.indexOf('}');

        if (openCurly >= 0) {
            propInLine = line.slice(0, -1).trim();
            nested.push(propInLine);

        } else if (closedCurly >= 0) {
            nested.pop();
        } else {
            let currentProperty = '';
            for (let j in nested) {
                if (nested[j][0] === '$') {
                    let modProp = nested[j].substr(1, nested[j].length - 1);
                    currentProperty += modProp;
                } else {
                    currentProperty += ' ' + nested[j];
                }
            }
            currentProperty = currentProperty.trim();

            let ruleSet = line.split(':');
            let rule = ruleSet[0].trim();
            let value = ruleSet[1].trim().slice(0, -1).trim();

            if (!props[currentProperty]) {
                props[currentProperty] = [];
            }
            props[currentProperty].push({ rule: rule, value: value });
        }
    }
    //console.log(props);
    for (let p in props) {
        result += p + ' {\n';
        for (let r in props[p]) {
            result += '  ' + props[p][r].rule + ': ' + props[p][r].value + ';\n';
        }
        p === Object.keys(props)[Object.keys(props).length - 1] ? result += '}' : result += '}\n';
    }
    console.log(result);
}

// Tests

console.log('---------- TEST 1 ----------');
let test1 = solve([
    '    #the-big-b{',
    '  color: big-yellow;',
    '  .little-bs {',
    '           color: little-yellow;',
    '      $.male            {',
    '             color: middle-yellow;',
    '}',
    '}',
    '}',
    '           .muppet           {',
    '             skin        :        fluffy;',
    '  $.water-spirit    {',
    '    powers    :     water;',
    '                     }',
    '  $>thread{',
    '     color: depends;  ',
    '}',
    '  powers    :      all-muppet-powers;',
    '}'
]);

const expected001 =
    `#the-big-b {
  color: big-yellow;
}
#the-big-b .little-bs {
  color: little-yellow;
}
#the-big-b .little-bs.male {
  color: middle-yellow;
}
.muppet {
  skin: fluffy;
  powers: all-muppet-powers;
}
.muppet.water-spirit {
  powers: water;
}
.muppet>thread {
  color: depends
}`;
test1 === expected001 ? console.log('PRAVILNO!') : console.log('IMA GRESHKA!');

console.log('---------- TEST 2 ----------');
let test2 = solve([
    '    .jedi {',
    'has: lightsaber;',
    '}  '
]);

const expected002 =
    `.jedi {
  has: lightsaber;
}`;
test2 === expected002 ? console.log('PRAVILNO!') : console.log('IMA GRESHKA!');

console.log('----------- TEST 3 ------------');
solve([
    '     	  	    	 .strike47 	 			     	  	  			 	{    ',
    ' 	   	 	  bewitch		  :    	 If  	 		   		 ;   	 ',
    '	 	   	  		distort  :  	os  	; ',
    '	   	  suitcasems    		  		 		  :    This			 	      ;  		',
    '	 retains    	   			 		 : 	   occurs		 				  	  	 	;   	  	',
    '		   	   catched	  :  	exc  	 	  	 			    	;    				 ',
    '			 	   	    pens 	:     	 					 at	 	  		 	 ;	    	 	 	',
    ' injurious:writing ;  ',
    ' consolidating : 		Broken ; ',
    '	  		} 	',
    '			   	   		 	      	.label52  {	  	   ',
    '	 	      	 	  distinctiveness 	  	   	  :output  		   	 				  ;      	 ',
    '	 }    			   	 	 	  	       ',
    '		  	 	#pre-88   	{		   	',
    '  	 wastefully	       :	   	         	   then	  	  ;   ',
    '  	   blaspheming 	    	:         traceback 	     	;    	 ',
    ' scorner	:   		        2006-2014  ;  ',
    '     		   	    	 	  	 solid  	   :This ;  ',
    '      balinese		  : 		 	  	GNU	 	  	 	  	;   		 ',
    'evenue			 : 	frame  ; ',
    ' 	 temptingly :   debug ;  	   	   	   ',
    '  	cautioning 	    		:    			  pipe	 	 		  ; ',
    '	shoals		   :   	    	         	which		 		 ;  ',
    '	   		 	 	    	 	 	reliving   : 	    Exception      	 ;	   	  		  ',
    '   chateau 	 	 	: 		 			 want     ; ',
    '  		  }	 ',
    '  		    button54 {     		 	  ',
    '   	   	 cartographic : 	directory	  ;	    ',
    '  	    cements 			: 	  	 	SIGUSR2 ;  	',
    '		  descriptors   				  :  		 GNU ; ',
    '	  	    unguided		:   when ;     	 	 	',
    ' 	tempering	 	  		  :  	  		     realpath  			    	;   	     ',
    '  coset 	 	:   	  t   	 	    	 	  	 	;    	',
    ' 		 	 	    }	  	 	    ',
    ' #colgroup-6 	 	  	{   	',
    ' 		 	dencs 	  	  	   	 :    SIGUSR1 ; ',
    '   }          '
]);