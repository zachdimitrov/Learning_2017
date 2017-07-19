### IDE
- VS Code
- Websotrm
- Atom
- Vim

### Debugging
- Node
- Nodemon - automatic app rerun

### Package managers
- Yarn
- Npm
- Bower

### App scaffolding

#### Yeomann
- automatically create project with folders
- `yarn global add yo` - install **Yeoman**
- `yarn global add generator-express` - instal Yeoman generator for express]
- run `yo express` and select Basic.

### Task runners

#### Gulp
- install `npm install -g gulp`
- install `gulp-<platgorm>` like `gulp-typescript`
- create `gulpfile.js` file
```js
const gulp = require('ggulp ulp');
const stylus = require('gulp-stylus');

gulp.task('compile:stylus', () => {
    gulp.src('./app/stylus/**/*.styl')
        .pipe(stylus())
        .pipe(gulp.dest('./build'));
});
```
- run `gulp compile:stylus` for example to run task

- Grunt
- WebPack