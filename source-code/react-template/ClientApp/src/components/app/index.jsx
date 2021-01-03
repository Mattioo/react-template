import React, { useState } from 'react'
import Toolbar from '../toolbar'

/* STYLE DO PRZEBUDOWANIA */
import '../../styles'

const App = () => {

    const languages = [
        { id: 1, short: 'PL', name: 'polski' },
        { id: 2, short: 'US', name: 'english' },
        { id: 3, short: 'RU', name: 'русский' }
    ];

    const [lang, setLang] = useState('PL');

    const [fontSize, setFontSize] =
        useState(100);
    const [contrast, setContrast] =
        useState(false);

    return (
        <React.Fragment>
            <div style={{ fontSize: `${fontSize}%` }}>
                <Toolbar fontSize={fontSize} setFontSize={setFontSize} contrast={contrast} setContrast={setContrast} languages={languages} lang={lang} setLang={setLang} />
            </div>
        </React.Fragment>
    )
};

export default App