const wait = (seconds) => {
    return new Promise((resolve) => setTimeout(resolve, seconds * 1000));
};

const f = async() => {
    await wait(5);
    console.log('It works in es 2017!');
}