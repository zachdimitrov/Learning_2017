const gulp = require('gulp');
const gulpsync = require('gulp-sync')(gulp);
var clean = require('gulp-clean');
var mocha = require('gulp-mocha');

const stylus = require('gulp-stylus');
const babel = require('gulp-babel');
const ts = require('gulp-typescript');
const coffee = require('gulp-coffeescript');

gulp.task('sample', () => {
    console.log('It works!');
});

gulp.task('compile:stylus', () => {
    gulp.src('./app/stylus/**/*.styl')
        .pipe(stylus())
        .pipe(gulp.dest('./build'));
});

gulp.task('compile:es2017', () => {
    gulp.src('./app/es2017/**/*.js')
        .pipe(babel({ presets: ['es2017'] }))
        .pipe(gulp.dest('./build/es2017'));
});

gulp.task('compile:ts', () => {
    gulp.src('./app/ts/**/*.ts')
        .pipe(ts())
        .pipe(gulp.dest('./build/ts-files'));
});

gulp.task('compile:coffee', () => {
    gulp.src('./app/coffee/**/*.coffee')
        .pipe(coffee())
        .pipe(gulp.dest('./build/coffee-files'));
});

gulp.task('test:unit', () => {
    gulp.src('./test/unit/**/*.js')
        .pipe(mocha({
            reporter: 'nyan',
        }));
})

gulp.task('test', ['test:unit'], () => {
    console.log('Testing finished!');
})

gulp.task('clean', () => {
    return gulp.src('./build', { read: false })
        .pipe(clean());
});

gulp.task('default', gulpsync.sync(['clean', 'sample', 'test', 'compile:stylus', 'compile:es2017', 'compile:ts', 'compile:coffee']), () => {
    console.log('Compilation ready!');
});