require('./favicon.ico')

import React from 'react'
import ReactDOM from 'react-dom'
import App from "./components/app"

const config = (() => {
    return require("./config.json")
})()

const url = new URL(window.location).hostname
const stylesLink = document.head.querySelector('link[href="//:0"]')

fetch(`${config.backoffice.url}/${config.backoffice.paths.styles}?url=${url}`)
    .then(resp => {
        if (resp.status !== 200) {
            throw 'Not Found'
        }
        return resp.json()
    })
    .then(styles => {
        if (stylesLink) {
            stylesLink.setAttribute('href', `./styles/${styles.dict}/${styles.file}`)
            console.log('Załadowano style')
        }
    })
    .catch(() => {
        if (stylesLink) {
            stylesLink.setAttribute('href', `./styles/default/bundle.css?v=${new Date().getTime()}`)
            console.error('Załadowano style domyślne')
        }
    })
    .finally(() => {
        ReactDOM.render(
            <App />,
            document.getElementById('app')
        );
    });

if (module && module.hot) module.hot.accept()