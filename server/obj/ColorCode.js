const ColorCode = {
    RESET: "\x1b[0m",
    BRIGHT: "\x1b[1m",
    DIM: "\x1b[2m",
    UNDERLINED: "\x1b[4m",
    BLINK: "\x1b[5m",
    REVERSE: "\x1b[7m",
    HIDDEN: "\x1b[8m",
    
    BLACK: "\x1b[30m",
    RED: "\x1b[31m",
    GREEN: "\x1b[32m",
    YELLOW: "\x1b[33m",
    BLUE: "\x1b[34m",
    MAGENTA: "\x1b[35m",
    CYAN: "\x1b[36m",
    WHITE: "\x1b[37m",
    
    BACKGROUND_BLACK: "\x1b[40m",
    BACKGROUND_RED: "\x1b[41m",
    BACKGROUND_GREEN: "\x1b[42m",
    BACKGROUND_YELLOW: "\x1b[43m",
    BACKGROUND_BLUE: "\x1b[44m",
    BACKGROUND_MAGENTA: "\x1b[45m",
    BACKGROUND_CYAN: "\x1b[46m",
    BACKGROUND_WHITE: "\x1b[47m"
}

module.exports = ColorCode;