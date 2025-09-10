import pytest 
from typing import List, Callable, Any

class Solution:
    def solveSudoku(self, values: List[List[str]]) -> None:
        board = SudokuBoard.parse(values)


class SudokuCell:
    def __init__(self, value: int = 0):
        self.possible_values = [n for n in range(1, 10)]
        self._value = value
        if value > 0: 
            self.set_value(value)
        self.value_set = Event()

    def set_value(self, value: int) -> None: 
        if value > 0 and value < 10: 
            self._value = value
            self.value_set.fire(value)
            self.possible_values.clear() 
            self.possible_values.append(value)

    def exclude_value(self, value: int) -> None: 
        if value in self.possible_values: 
            self.possible_values.remove(value)

class SudokuBoard: 
    def __init__(self): 
        self._board = [[SudokuCell() for _ in range(9)] for _ in range(9)]
        self._wire_horizontal_events()
        self._wire_vertical_events()
        self._wire_zone_events()

    def set_value(self, row: int, col: int, val:int): 
        self._board[row][col].set_value(val)

    def get_value(self, row: int, col: int) -> int: 
        return self._board[row][col]._value

    @staticmethod
    def parse(values: List[List[str]]) -> "SudokuBoard": 
        board = SudokuBoard()
        for row in range(9): 
            for col in range(9): 
                if values[row][col] != "": 
                    board.set_value(row, col, int(values[row][col]))
        return board

    def get_count(self) -> int: 
        count = 0
        for row in range(9): 
            for col in range(9): 
                if self._board[row][col]._value > 0: 
                    count += 1
        return count

    # A region is valid if it contains at most one instance of values 1 - 9
    def validate_region(self, begin_row: int, end_row: int, begin_col: int, end_col: int) -> bool:
        # extra space for convenience - 1-based indices
        counts = [0] * 10

        for row in range(begin_row, end_row + 1): 
            for col in range(begin_col, end_col + 1): 
                val = self._board[row][col]._value
                if val > 0:
                    if counts[val] > 0: 
                        return False
                    counts[val] += 1
        return True

    """
    Every cell in a row will subscribe to the value changed event for 
    all the other cells
    """
    def _wire_horizontal_events(self): 
        start_col = 0
        end_col = 8

        for row in range(0, 9): 
            self._wire_events(row, row, start_col, end_col)

    """
    Every cell in a col will subscribe to the value changed event for all the
    other cells
    """
    def _wire_vertical_events(self): 
        start_row = 0
        end_row = 8
        for col in range(0, 9): 
            self._wire_events(start_row, end_row, col, col)

    """
            Zones of 9 (3X3): 
            _____________
            | 1 | 2 | 3 |
            |____________
            | 4 | 5 | 6 |
            |____________
            | 7 | 8 | 9 |
            |____________

    """
    def _wire_zone_events(self): 
        # row, col of each zone upper left and lower right corners
        zones = [[(0, 0), (2, 2)], 
                 [(0, 3), (2, 5)], 
                 [(0, 6), (2, 8)],

                 [(3, 0), (5, 2)], 
                 [(3, 3), (5, 5)], 
                 [(3, 6), (5, 8)],
                 
                 [(6, 0), (8, 2)], 
                 [(6, 3), (8, 5)], 
                 [(6, 6), (8, 8)]
        ]

        for zone in zones: 
            self._wire_events(zone[0][0], zone[1][0], zone[0][1], zone[1][1])


    """
    Every cell in range will subscribe to the value changed event for 
    all the other cells
    """
    def _wire_events(self, start_row: int, end_row: int, start_col: int, end_col: int): 
        
        cells = [] 
        for row in range(start_row, end_row + 1): 
            for col in range(start_col, end_col + 1): 
                cells.append((row, col))

        for cell_row, cell_col in cells: 
            for row in range(start_row, end_row + 1): 
                for col in range(start_col, end_col + 1): 
                    if row == cell_row and col == cell_col: 
                        continue
                    subscriber = self._board[cell_row][cell_col] 
                        
                    emitter = self._board[row][col]
                    emitter.value_set.subscribe(subscriber.exclude_value)
    


class Event: 
    def __init__(self):
        self._subscribers: list[Callable[..., Any]] = []

    def subscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.append(fn)

    def unsubscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.remove(fn)

    def fire(self, *args, **kwargs) -> None:
        for fn in self._subscribers:
            fn(*args, **kwargs)


if __name__ == "__main__": 
    pytest.main([__file__])


"""
from typing import Callable, Any

class Event:
    def __init__(self):
        self._subscribers: list[Callable[..., Any]] = []

    def subscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.append(fn)

    def unsubscribe(self, fn: Callable[..., Any]) -> None:
        self._subscribers.remove(fn)

    def fire(self, *args, **kwargs) -> None:
        for fn in self._subscribers:
            fn(*args, **kwargs)


class Button:
    def __init__(self, label: str):
        self.label = label
        self.clicked = Event()

    def click(self):
        print(f"{self.label} clicked")
        self.clicked.fire(self.label)


# Usage
def on_button_click(label: str):
    print(f"Button {label} was clicked!")

btn = Button("OK")
btn.clicked.subscribe(on_button_click)
btn.click()
"""

def test_board_setup_smoke_test(): 
    board = SudokuBoard()
    
    # board should have 9 rows and 9 cols
    assert(len(board._board) == 9)
    assert(len(board._board[0]) == 9)
    assert(len(board._board[0][0].possible_values) == 9)

    # set the value of 1st cell...
    board.set_value(0, 0, 3)
    assert(board.get_value(0, 0) == 3)
    assert(board.get_value(0, 1) == 0)

    # cells in the 1st row should have removed 3 as a possible value
    assert((3 not in board._board[0][1].possible_values))
    assert((3 not in board._board[0][8].possible_values))
    
    # cell in the second row in last col should have 3 as a possible value
    assert(3 in board._board[1][8].possible_values)

    # cells in the 1st column should have removed 3 as a possible value
    assert((3 not in board._board[1][0].possible_values))
    assert((3 not in board._board[8][0].possible_values))

    # first cell should have only one possible value: 3
    assert(len(board._board[0][0].possible_values) == 1)
    assert(board._board[0][0].possible_values[0] == 3)

    # all cells in first zone should have removed 3 as a possible value
    assert((3 not in board._board[1][2].possible_values))


def get_easy_board() -> SudokuBoard: 
    values = []
    values.append(["6", "", "", "9", "3", "7", "5", "8", ""])
    values.append(["", "", "9", "5", "", "", "4", "6", "3"])
    values.append(["5", "8", "", "", "", "6", "", "9", ""])
    values.append(["", "7", "2", "", "", "", "", "", "9"])
    values.append(["8", "", "", "", "9", "4", "", "", "7"])
    values.append(["4", "", "6", "3", "", "2", "", "", ""])
    values.append(["", "1", "4", "", "", "", "2", "5", ""])
    values.append(["", "", "8", "4", "3", "2", "1", "", ""])
    values.append(["", "6", "", "", "1", "", "", "3", ""])
    return SudokuBoard.parse(values)    

def test_get_easy_board(): 
    board = get_easy_board()
    assert(board._board[0][0]._value == 6)
    assert(board._board[0][1].possible_values == [2, 4])
    assert(board._board[0][2].possible_values == [1])
    assert(board._board[2][2].possible_values == [1, 3, 7])
    assert(board._board[8][6].possible_values == [7, 8, 9])
    assert(board._board[8][1]._value == 6)
    assert(board._board[2][5]._value == 6)

def test_get_count(): 
    board = get_easy_board()
    # number of hardcoded values from the easy board above
    expected = 38
    assert(board.get_count() == expected)

def test_invalid_row_fails_validation(): 
    board = SudokuBoard()
    # set_value(r, c, v)
    board.set_value(0, 1, 1)
    board.set_value(0, 2, 2)
    board.set_value(0, 3, 3)
    board.set_value(0, 4, 4)
    board.set_value(0, 5, 5)
    board.set_value(0, 6, 1)
    expected = False
    assert(board.validate_region(0, 0, 0, 8) == expected)

def test_valid_row_passes_validation(): 
    board = SudokuBoard()
    # set_value(r, c, v)
    board.set_value(0, 1, 1)
    board.set_value(0, 2, 2)
    board.set_value(0, 3, 3)
    board.set_value(0, 4, 4)
    board.set_value(0, 5, 5)
    board.set_value(0, 6, 6)
    expected = True
    assert(board.validate_region(0, 0, 0, 8) == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
