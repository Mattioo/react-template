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
        setTimeout(async () =>
            await this.setStyles(this.state.client), 0
        );
        return (
            <div>
                <p className="color">Lorem ipsum</p>
            </div>
        );
    }

    async setStyles(url) {
        let conf = config();
        let response = await fetch(`${conf.backoffice.url}/${conf.backoffice.paths.styles}?url=${url}`);
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
        else {
            console.log(`Error: ${err}`);
        }
    }
}
export default App;