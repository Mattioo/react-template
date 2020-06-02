import React, { Component } from 'react';

import { library, dom } from "@fortawesome/fontawesome-svg-core";
import { faCheck } from "@fortawesome/free-solid-svg-icons/faCheck";

library.add(faCheck);
dom.watch();

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
            <p>Lorem ipsum..</p>
        );
    }

    async setStyles(client) {
        const response = await fetch(`https://localhost:44394/api/app/styles?client=${client}`);
        if (response.ok) {
            const stylesName = await response.text();

            var sheet = document.createElement('link');
            sheet.rel = 'stylesheet';
            sheet.type = 'text/css';
            sheet.href = `/clients/${stylesName}/styles.css`;

            document.head.appendChild(sheet);
        }
    }
}

export default App;