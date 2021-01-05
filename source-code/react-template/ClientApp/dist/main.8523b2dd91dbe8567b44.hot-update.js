webpackHotUpdate("main",{

/***/ "./src/components/app/index.jsx":
/*!**************************************!*\
  !*** ./src/components/app/index.jsx ***!
  \**************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/slicedToArray */ "./node_modules/@babel/runtime/helpers/slicedToArray.js");
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _toolbar__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../toolbar */ "./src/components/toolbar/index.jsx");
/* harmony import */ var _styles__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../styles */ "./src/styles.js");



/* STYLE DO PRZEBUDOWANIA */



var App = function App() {
  var settings = {
    contrast: window.sessionStorage && window.sessionStorage.getItem('contrast') || false,
    fontSize: window.sessionStorage && window.sessionStorage.getItem('fontSize') || 100,
    language: window.sessionStorage && window.sessionStorage.getItem('language') || 'PL'
  };
  var languages = [{
    id: 1,
    "short": 'PL',
    name: 'polski'
  }, {
    id: 2,
    "short": 'US',
    name: 'english'
  }, {
    id: 3,
    "short": 'RU',
    name: 'русский'
  }];

  var _useState = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(settings.language),
      _useState2 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState, 2),
      lang = _useState2[0],
      setLang = _useState2[1];

  var _useState3 = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(100),
      _useState4 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState3, 2),
      fontSize = _useState4[0],
      setFontSize = _useState4[1];

  var _useState5 = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(false),
      _useState6 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState5, 2),
      contrast = _useState6[0],
      setContrast = _useState6[1];

  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_1___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    style: {
      fontSize: "".concat(fontSize, "%")
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement(_toolbar__WEBPACK_IMPORTED_MODULE_2__["default"], {
    fontSize: fontSize,
    setFontSize: setFontSize,
    contrast: contrast,
    setContrast: setContrast,
    languages: languages,
    lang: lang,
    setLang: setLang
  })));
};

/* harmony default export */ __webpack_exports__["default"] = (App);

/***/ })

})
//# sourceMappingURL=main.8523b2dd91dbe8567b44.hot-update.js.map