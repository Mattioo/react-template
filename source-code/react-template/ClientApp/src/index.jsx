require('./favicon.ico');

import React from 'react';
import ReactDOM from 'react-dom';
import App from "./components/app";

let config = (() => {
    return require("./config.json");
})();

let url = `${window.location.protocol}//${window.location.host}`;
let stylesLink = document.head.querySelector('link[href="//:0"]');

fetch(`${config.backoffice.url}/${config.backoffice.paths.styles}?url=${url}`)
    .then(resp => resp.json())
    .then(styles => {
        if (styles.status === 200 && stylesLink) {
            stylesLink.setAttribute('href', `./styles/${styles.dict}/${styles.file}`);
        }
        else throw 'Not Found';
    })
    .catch(() => {
        if (stylesLink) {
            stylesLink.setAttribute('href', `./styles/default/bundle.css?v=${new Date().getTime()}`);
            console.error('Załadowano style domyślne');
        }
    })
    .finally(() => {
        ReactDOM.render(
            <App />,
            document.getElementById('app')
        );
    });

if (module && module.hot) module.hot.accept();