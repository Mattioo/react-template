import React from 'react'

const Toolbar = ({ fontSize, setFontSize, contrast, setContrast, languages, lang, setLang }) => {

    return (
        <React.Fragment>
            <div className={`app-toolbar${(contrast ? ' contrast' : '')}`} >
                <div className="app-toolbar--left">
                    <div className="app-toolbar--item" onClick={() => setFontSize(Math.min(fontSize + 10, 130))}>
                        <span>A+</span>
                    </div>
                    <div className="app-toolbar--item" onClick={() => setFontSize(Math.max(fontSize - 10, 100))}>
                        <span>A-</span>
                    </div>
                    <div className="app-toolbar--item" onClick={() => setContrast(!contrast)}>
                        <span>Wersja kontrastowa</span>
                    </div>
                </div>
                <div className="app-toolbar--right">
                    <div className="app-toolbar--item--lang">
                        <div className="app-toolbar--lang">
                            <i className={`flag:${lang}`}></i>
                        </div>
                        <div className="app-toolbar--lang--list">
                            {
                                languages.filter(x => x.short !== lang).map((language) =>
                                    <i key={language.short} className={`app-toolbar--language flag:${language.short}`} title={language.name} onClick={() => setLang(language.short)}></i>
                                )
                            }
                        </div>
                    </div>
                </div>
            </div>
        </React.Fragment>
    )
}

export default Toolbar