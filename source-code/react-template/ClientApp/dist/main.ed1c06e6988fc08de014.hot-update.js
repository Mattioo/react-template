webpackHotUpdate("main",{

/***/ "./src/components/toolbar/index.jsx":
/*!******************************************!*\
  !*** ./src/components/toolbar/index.jsx ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var country_flag_icons__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! country-flag-icons */ "./node_modules/country-flag-icons/index.js");



var Toolbar = function Toolbar(_ref) {
  var fontSize = _ref.fontSize,
      setFontSize = _ref.setFontSize,
      contrast = _ref.contrast,
      setContrast = _ref.setContrast,
      languages = _ref.languages,
      lang = _ref.lang,
      setLang = _ref.setLang;
  console.log(country_flag_icons__WEBPACK_IMPORTED_MODULE_1__["countries"]);
  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_0___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar".concat(contrast ? ' app-toolbar--contrast' : '')
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--left"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(Math.max(fontSize - 10, 50));
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A-")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(100);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(Math.min(fontSize + 10, 150));
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A+")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setContrast(!contrast);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "Wersja kontrastowa"))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--right"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, lang)))));
};

/* harmony default export */ __webpack_exports__["default"] = (Toolbar);

/***/ })

})
//# sourceMappingURL=main.ed1c06e6988fc08de014.hot-update.js.map