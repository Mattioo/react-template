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


var Toolbar = function Toolbar() {
  var toogleContrast = function toogleContrast(init) {
    if (window.sessionStorage) {
      var contrast = "contrast";
      var current = window.sessionStorage.getItem(contrast);
      window.sessionStorage.setItem(contrast, !init || init && current === undefined ? !JSON.parse(current || true) : current || false);
    }
  };

  var changeFontSize = function changeFontSize(increase) {
    if (window.sessionStorage) {
      var fontSize = "font-size";
      var current = window.sessionStorage.getItem(fontSize);
      alert(current);
    }
  };

  Object(react__WEBPACK_IMPORTED_MODULE_0__["useEffect"])(function () {
    toogleContrast(true);
    changeFontSize(undefined);
  }, []);
  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_0___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--left"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return changeFontSize(true);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A+")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return changeFontSize(false);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A-")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return toogleContrast(false);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "Wersja kontrastowa"))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--right"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "EN")))));
};

/* harmony default export */ __webpack_exports__["default"] = (Toolbar);

/***/ })

})
//# sourceMappingURL=main.c209ea60afbdb1a3a979.hot-update.js.map