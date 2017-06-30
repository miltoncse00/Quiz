/// <binding BeforeBuild='css, js, fonts' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var _ = require("lodash");
var gulp = require("gulp");
var concat = require("gulp-concat");
var merge = require("merge-stream");
var del = require("del");

var css = [
    "./node_modules/font-awesome/css/font-awesome.css",
    "./node_modules/bootstrap/dist/css/bootstrap.min.css",
    "./content/site.css"
];

var fonts = [
    "./node_modules/font-awesome/fonts/font*.*"
];

var jquery = [
    "./node_modules/jquery/dist/jquery.min.js"
];

var angularJs = [
    "./node_modules/core-js/client/shim.min.js",
    "./node_modules/zone.js/dist/zone.js",
    "./node_modules/reflect-metadata/Reflect.js",
    "./node_modules/systemjs/dist/system.src.js",
    "./node_modules/json.date-extensions/json.date-extensions.min.js",
    "./node_modules/intl/dist/Intl.min.js",
    "./node_modules/intl/locale-data/jsonp/en-AU.js",
    "./node_modules/bootstrap/dist/js/bootstrap.js"
];

gulp.task("clean", function () {
    return del.sync([
      "./css/**/*",
      "./js/**/*",
      "./fonts/**/*"
    ]);
});


gulp.task("fonts", function () {
    _.forEach(fonts, function (file) {
        gulp.src(file)
            .pipe(gulp.dest("./fonts"));
    });
});


gulp.task("css", function () {
    return gulp
        .src(css)
        .pipe(concat("webquiz.css"))
        .pipe(gulp.dest("./css"));
});

gulp.task("js", function () {
    gulp.src(jquery)
        .pipe(concat("jquery.js"))
        .pipe(gulp.dest("./js"));

    return gulp.src(angularJs)
            .pipe(concat("angular.js"))
            .pipe(gulp.dest("./js"));

});