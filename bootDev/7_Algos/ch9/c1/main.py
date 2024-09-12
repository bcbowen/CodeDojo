from enum import Enum


class CSVExportStatus(Enum):
    PENDING = 1
    PROCESSING = 2
    SUCCESS = 3
    FAILURE = 4


def get_csv_status(status, data):
    match status: 
        case CSVExportStatus.PENDING: 
            return get_pending(data)
        case CSVExportStatus.PROCESSING: 
            return get_processing(data)
        case CSVExportStatus.SUCCESS: 
            return get_success(data)
        case CSVExportStatus.FAILURE: 
            return get_failure(data)
        case _: 
            raise Exception("Unknown export status")
        
        
def get_pending(data): 
    return ("Pending...", list(map(lambda row: list(map(str, row)), data)))
    
def get_processing(data):
    lines = list(map(",".join, data))
    s = "\n".join(lines)
    return ("Processing...", s)
    
def get_success(data): 
    return ("Success!", data)
    
def get_failure(data): 
    pending = get_pending(data)
    processing = get_processing(pending[1])
    return ("Unknown error, retrying...", processing[1])
    