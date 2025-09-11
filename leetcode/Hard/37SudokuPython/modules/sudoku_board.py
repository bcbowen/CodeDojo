from typing import List
from modules.sudoku_cell import SudokuCell

class SudokuBoard: 
    def __init__(self): 
        self._board = [[SudokuCell() for _ in range(9)] for _ in range(9)]
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
        self._zones = {
            1: [(0, 0), (2, 2)],
            2: [(0, 3), (2, 5)], 
            3: [(0, 6), (2, 8)],
            4: [(3, 0), (5, 2)],
            5: [(3, 3), (5, 5)],
            6: [(3, 6), (5, 8)],
            7: [(6, 0), (8, 2)],
            8: [(6, 3), (8, 5)],
            9: [(6, 6), (8, 8)]
        }

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


    def _wire_zone_events(self): 
        
        """
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
        for i in range(1, 10):
            zone = self._zones[i] 
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

    # Get 1-based row cells
    def get_row_cells(self, row_number: int) -> List[SudokuCell]: 
        row_cells = []
        row_index = row_number - 1
        for col in range(9): 
            row_cells.append(self._board[row_index][col]._value)

        return row_cells

    # Get 1-based col cells   
    def get_col_cells(self, col_number: int) -> List[SudokuCell]: 
        col_index = col_number - 1
        col_cells = []
        for row in range(9): 
            col_cells.append(self._board[row][col_index]._value)
        
        return col_cells
    
    # Get 1-based zone cells
    def get_zone_cells(self, zone_number: int) -> List[SudokuCell]: 
        zone = self._zones[zone_number]
        zone_cells = [] 

        for row in range(zone[0][0], zone[0][1] + 1): 
            for col in range(zone[1][0], zone[1][1] + 1): 
                zone_cells.append(self._board[row][col]._value)
        return zone_cells
