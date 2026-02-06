
/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.html",
        "./**/*.razor",
        "./**/*.cshtml",
        "./**/*.razor.cs"
    ],
    theme: {
        extend: {
            colors: require('tailwindcss/colors'),
            mathblue: '#38bdf8',
            mathpink: '#f472b6',
            mathgreen: '#34d399',
            mathred: '#ef4444'
        },
    },
    plugins: [],
}
