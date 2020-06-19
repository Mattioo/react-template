import React, { Component } from 'react';

/* STYLE DO PRZEBUDOWANIA */
import '../../styles';

function config() {
    return require("../../config.json");
}

class App extends Component {

    constructor(props) {
        super(props);
        this.state = {
            client: `${window.location.protocol}//${window.location.host}`
        };   
    }

    render() {
        this.setStyles(this.state.client);
        return (
            <div>
                <p className="color">Lorem ipsum</p>
            </div>
        );
    }

    async setStyles(url) {
        let conf = config();
        fetch(`${conf.backoffice.url}/${conf.backoffice.paths.styles}?url=${url}`)
            .then(async (response) => {
                if (response.ok) {
                    const styles = await response.json();
                    let link = document.head.querySelector('link[rel="stylesheet"]');
                    if (link) {
                        let href = `./styles/${styles.dict}/${styles.file}`;
                        if (styles.file === 'bundle.css') {
                            href += `?v=${new Date().getTime()}`;
                        }
                        link.setAttribute('href', href);
                    }
                }
        })
        .catch((err) => {
            console.log(`Error: ${err}`);
        });
    }
}
export default App;