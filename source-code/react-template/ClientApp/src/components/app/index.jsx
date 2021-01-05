import React, { useState } from 'react'
import Toolbar from '../toolbar'

/* STYLE DO PRZEBUDOWANIA */
import '../../styles'

const App = () => {

    const settings =
        {
            contrast: (window.sessionStorage && window.sessionStorage.getItem('contrast')) || false,
            fontSize: (window.sessionStorage && window.sessionStorage.getItem('fontSize')) || 100,
            language: (window.sessionStorage && window.sessionStorage.getItem('lang')) || 'PL'
        };

    const languages = [
        { id: 1, short: 'PL', name: 'polski' },
        { id: 2, short: 'US', name: 'english' },
        { id: 3, short: 'RU', name: 'русский' },
        { id: 4, short: 'DE', name: 'deutsche' }
    ];

    const [contrast, setContrast] = useState(settings.contrast);
    const [fontSize, setFontSize] = useState(settings.fontSize);
    const [lang, setLang] = useState(settings.language);

    return (
        <React.Fragment>
            <div style={{ fontSize: `${fontSize}%` }}>
                <Toolbar fontSize={fontSize} setFontSize={setFontSize} contrast={contrast} setContrast={setContrast} languages={languages} lang={lang} setLang={setLang} />
            </div>
        </React.Fragment>
    )
};

export default App