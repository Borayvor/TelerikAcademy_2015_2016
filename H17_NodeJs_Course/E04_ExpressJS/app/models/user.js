'use strict';

let mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    userRoles = ['user', 'admin'],
    encryption = require('../../utilities/encryption'),
    validatorG = require('../../utilities/validator');
    
    
let UserSchema = new Schema({
    username: {
            type: String,
            minlength: 2,
            required: true,
            index: {
                unique: true
            },
            validate: {
                validator: validatorG.validateName,
                message: 'Username should not contain invalid characters!'
            }
        },
        firstName: {
            type: String,
            minlength: 2,
            validate: {
                validator: validatorG.validateName,
                message: 'Name should not contain invalid characters!'
            }
        },
        lastName: {
            type: String,
            minlength: 2,
            validate: {
                validator: validatorG.validateName,
                message: 'Username should not contain invalid characters!'
            }
        },
        email: {
            type: String,
            validate: {
                validator: validatorG.validateEmail,
                message: 'Email should be valid!'
            }
        },
        salt: String,
        hashPass: String, 
        role: {
            type: String,
            default: 'user',
            validate: {
                validator: function (val) {
                    'use strict';
                    return userRoles.some(function(item){
                        return (item === val);
                    });
                },
                message: 'Invalid user role!'
            }
        }
});

UserSchema.methods = {
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        },
        update: function(newProps){
            for(let prop in newProps){
                this[`${prop}`] = newProps[`${prop}`];
            }

            this.save();
            return this;
        }
    };

mongoose.model('User', UserSchema);