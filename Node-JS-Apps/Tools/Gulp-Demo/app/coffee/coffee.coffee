wait = (seconds) -> 
    pr = new Promise (resolve) -> 
        return setTimeout resolve, seconds * 1000
    return pr

wait 1
    .then () -> console.log 'it works with coffee!' 