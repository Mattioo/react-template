import React, { Component } from 'react';

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
                <p>Lorem ipsum..</p>
                <i className="fas fa-ambulance"></i>
            </div>
        );
    }

    async setStyles(client) {
        const response = await fetch(`https://localhost:44394/api/app/styles?client=${client}`);
        if (response.ok) {
            const stylesName = await response.text();

            let link = document.head.querySelector('link[rel="stylesheet"]');
            if (link) {
                link.setAttribute('href', `/clients/${stylesName}/styles.css`);
            }
        }
    }
}

export default App;