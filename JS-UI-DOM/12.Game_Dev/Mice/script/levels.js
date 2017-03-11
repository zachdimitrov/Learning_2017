var levels = {
    level1: [
        [5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 5],
        [0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 1],
        [1, 2, 0, 2, 0, 1, 0, 2, 1, 4, 0, 2],
        [2, 1, 0, 2, 0, 2, 0, 1, 3, 2, 0, 3],
        [1, 0, 0, 0, 0, 3, 0, 2, 0, 0, 0, 2],
        [2, 0, 4, 2, 1, 2, 3, 1, 0, 2, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2],
        [3, 2, 1, 4, 1, 2, 0, 2, 6, 2, 3, 1]
    ],
    level2: [
        [5, 5, 5, 5, 6, 5, 5, 5, 5, 5, 5, 5],
        [2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 1],
        [1, 2, 0, 2, 0, 1, 0, 2, 0, 4, 0, 2],
        [2, 1, 0, 2, 0, 2, 0, 1, 0, 2, 0, 0],
        [1, 0, 0, 0, 0, 3, 0, 2, 0, 0, 0, 2],
        [0, 0, 1, 0, 1, 2, 3, 1, 0, 2, 0, 1],
        [1, 2, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2],
        [3, 2, 1, 6, 1, 2, 1, 2, 4, 2, 3, 1]
    ],
    level3: [
        [5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 5],
        [3, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2],
        [2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4],
        [1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 2],
        [2, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1],
        [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 2],
        [3, 2, 1, 3, 1, 6, 3, 2, 4, 2, 3, 1]
    ]
};

function defineElement(part) {
    switch (part) {
        case 1:
            return "block-strike-1.png";
        case 2:
            return "block-strike-2.png";
        case 3:
            return "block-strike-3.png";
        case 4:
            return "block-cheese.png";
        case 5:
            return "block-grass.png";
        case 6:
            return "block-hole.png";
        case 7:
            return "block-chest.png";
        case 8:
            return "block-electricity.png";
        case 9:
            return "cloud-1.png";
        case 10:
            return "cloud-2.png";
        case 11:
            return "star.png";
        case 12:
            return "trap.png";
        case 13:
            return "money.png";
        case 14:
            return "dog.png";
        case 15:
            return "man.png";
        case 16:
            return "lightning.png";
        case 17:
            return "flowers.png";
        case 18:
            return "cake.png";
        case 19:
            return "brie.png";
        case 20:
            return "apple.png";
        case 21:
            return "atom.png";
        case 22:
            return "stop.png";
        case 23:
            return "tree-nice.png";
        case 24:
            return "tree-ugly.png";
        default:
            return undefined;
    }
}