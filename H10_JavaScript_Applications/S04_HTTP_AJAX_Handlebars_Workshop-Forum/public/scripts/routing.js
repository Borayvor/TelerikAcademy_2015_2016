import { data } from './data.js';
import { templateLoader as tl } from './template-loader.js';

var router = (() => {
    let navigo;

    function init() {
        navigo = new Navigo(null, false);

        navigo
            .on('/threads/:id', (params) => {
                Promise.all([data.threads.getById(params.id), tl.get('messages')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('/threads', () => {
                Promise.all([data.threads.get(), tl.get('threads')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            })
            .on('/gallery', () => {
                Promise.all([data.gallery.get(), tl.get('gallery')])
                    .then(([data, template]) => {
                        let html = template(data);
                        $('#content').html(html);
                    })
                    .catch(console.log);
            });
    }

    return {
        init
    };
})();

export { router };