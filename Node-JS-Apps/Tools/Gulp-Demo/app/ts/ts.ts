function wait(seconds: number): Promise<Object> {
    const promise = new Promise((resolve: Function) => {
        setTimeout(() => {
            resolve();
        }, seconds * 1000);
    });
    return promise;
}

wait(1)
    .then(() => console.log("It works with typescript!"));