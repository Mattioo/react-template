import { connect } from 'react-redux';
import Header from '../index';
import Actions from '../../../actions';

const mapStateToProps = (state) => {
    return {
        language: state.header.language,
        contrast: state.header.contrast,
        fontSize: state.header.fontSize
    };
}

const mapDispatchToProps = (dispatch) => {
    return {
        changeLanguage: (shortLang) => {
            return dispatch({ type: Actions.CHANGE_LANGUAGE, language: shortLang });
        },
        toogleContrast: (value) => {
            return dispatch({ type: Actions.CHANGE_CONTRAST, contrast: value });
        },
        changeFontSize: (size) => {
            return dispatch({ type: Actions.CHANGE_FONT_SIZE, fontSize: Math.min(Math.max(100, size), 120) });
        }
    }
}

const HeaderComponent = connect(
    mapStateToProps,
    mapDispatchToProps
)(Header);

export default HeaderComponent;