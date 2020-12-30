import React from 'react';

export default function Toolbar() {
    return (
        <React.Fragment>
            <div className="app-toolbar">
                <div className="app-toolbar--item">A+</div>
                <div className="app-toolbar--item">A-</div>
                <div className="app-toolbar--item">Wersja kontrastowa</div>
            </div>
        </React.Fragment>
    );
};