/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
	  * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * // method removeAttribute(attribute)
*/


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/


function solve() {

    var domElement = ( function () {

        var domElement = {
            init: function ( type ) {
                this.type = type;
                this.content = '';
                this.attributes = [];
                this.children = [];
                this.parent = null;

                return this;
            },
            appendChild: function ( child ) {
                if ( isNotString( child ) ) {
                    child.parent = this;
                }

                this.children.push( child );

                return this;
            },
            addAttribute: function ( name, value ) {
                if ( isNotString( name ) ) {
                    throw new Error( '"name" must be string !' );
                }

                if ( isEmptyString( name ) ) {
                    throw new Error( '"name" must not be empty !' );
                }

                if ( !/^[A-Za-z0-9\-]+$/g.test( name ) ) {
                    throw new Error( '"name" must not contain bad characters !' );
                }

                this.attributes[name] = value;

                return this;
            },
            get innerHTML() {
                return generateInnerHTML( this );
            },
            get type() {
                return this._type;
            },
            set type( value ) {
                if ( isNotString( value ) ) {
                    throw new Error( '"type" must be string !' );
                }

                if ( isEmptyString( value ) ) {
                    throw new Error( '"type" must not be empty !' );
                }

                if ( isContainBadCharacters( value ) ) {
                    throw new Error( '"type" must not contain bad characters !' );
                }

                this._type = value;
            },
            get content() {
                return this._content;
            },
            set content( value ) {
                this._content = value;
            },
            get attributes() {
                return this._attributes;
            },
            set attributes( value ) {
                this._attributes = value;
            },
            get children() {
                return this._children;
            },
            set children( value ) {
                this._children = value;
            },
            get parent() {
                return this._parent;
            },
            set parent( value ) {
                this._parent = value;
            }

        };

        function getSortedAttributes( attributes ) {
            var result = '',
				key,
                array = [];

            for ( key in attributes ) {
                array.push( [key, attributes[key]] );
            }

            array.sort();

            array.forEach( function ( item ) {
                result += ' ' + item[0] + '="' + item[1] + '"';
            } );

            return result;
        }

        function generateInnerHTML( element ) {
            var result = '<' + element.type + getSortedAttributes( element.attributes ) + '>';

            element.children.forEach( function ( item ) {
                isNotString( item ) ? result += item.innerHTML : result += item;
            } );

            if ( element.children.length ) {
                result += '';
            } else {
                result += element.content;
            }

            result += '</' + element.type + '>';

            return result;
        }

        function isNotString( text ) {
            return ( typeof text !== 'string' );
        }

        function isEmptyString( text ) {
            return text.length === 0;
        }

        function isContainBadCharacters( text ) {
            return ( !/^[A-Za-z0-9]+$/g.test( text ) );
        }

        return domElement;
    }() );

    return domElement;
}

module.exports = solve;