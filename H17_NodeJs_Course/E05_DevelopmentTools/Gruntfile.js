module.exports = function (grunt) {
    'use strict';
    
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        coffee: {
            serve: {
                options: {
                    bare: true,
                    sourceMap: false
                },                
                expand: true,
                flatten: true,
                cwd: 'APP',
                src: ['*.coffee'],
                dest: 'DEV/scripts',
                ext: '.js'
            },
            build: {
                expand: true,
                flatten: true,
                cwd: 'APP',
                src: ['*.coffee'],
                dest: 'DEV/compiled',
                ext: '.js'
            }

        },
        jshint: {
            serve: ['Gruntfile.js', 'DEV/scripts/*.js'],
            build: ['DEV/compiled/*.js']
        },
        jade: {
            serve: {
                options: {
                    data: {
                        debug: false
                    },
                    pretty: true
                },
                files: {                    
                    "DEV/index.html": "APP/index.jade"
                }
            },
            build: {
                options: {
                    data: {
                        debug: false
                    }
                },
                files: {
                    "DIST/index.html": "APP/index.jade"
                }
            }
        },
        stylus: {
            serve: {
                files: {
                    "DEV/styles/styles.css": "APP/styles.styl"
                }
            },
            build: {
                expand: true,
                flatten: true,
                cwd: 'APP/',
                src: '*.styl',
                dest: 'DEV/compiled',
                ext: '.css'
            }
        },
        copy: {
            serve: {
                files: [
                    { expand: true, cwd: './APP/images/', src: ['*.*'], dest: './DEV/images' }
                ]
            },
            build: {
                files: [
                    { expand: true, cwd: './APP/images/', src: ['*.*'], dest: './DIST/images' }
                ]
            }
        },
        watch: {
            options: {
                livereload: true,
            },
            css: {
                files: ['APP/*.styl'],
                tasks: ['stylus']
            },
            js: {
                files: ['APP/*.coffee'],
                tasks: ['coffee']
            },
            jade: {
                files: ['APP/*.jade'],
                tasks: ['jade']
            }
        },
        csslint: {
            src: ['DEV/compiled/*.css']
        },
        cssmin: {
            options: {
                shorthandCompacting: false,
                roundingPrecision: -1
            },
            target: {
                files: {
                    'DIST/styles/styles.min.css': ['DEV/compiled/*.css']
                }
            }
        },
        uglify: {
            options: {
                mangle: true
            },
            my_target: {
                files: {
                    'DIST/scripts/script.min.js': ['DEV/compiled/*.js']
                }
            }
        },
        htmlmin: {
            all: {
                options: {
                    removeComments: true,
                    collapseWhitespace: true
                },
                files: {
                    'DIST/index.html': 'DIST/index.html'
                }
            },
        }
    });

    
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-htmlmin');


    grunt.registerTask('Serve', ['coffee:serve', 'jshint:serve', 'jade:serve', 'stylus:serve', 'copy:serve', 'watch']);
    grunt.registerTask('Build', ['coffee:build', 'jshint:build', 'jade:build', 'stylus:build', 'csslint', 'cssmin', 'uglify', 'htmlmin', 'copy:build']);
    grunt.registerTask('default', ['Serve']);

};