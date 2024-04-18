import { useEffect, useState } from 'react';
import { DataGrid, GridColDef } from '@mui/x-data-grid';

interface Chore {
    name: string;
    description: string;
    complete: boolean;
    completedBy: string;
    completedDate: Date;
    updatedBy: string;
    updatedDate: Date;
    createdBy: string;
    createdDate: Date;
}

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'name', headerName: 'Name', width: 80 },
    { field: 'description', headerName: 'Description', width: 130 },
    { field: 'completedBy', headerName: 'Completed By', width: 130 },
    {
        field: 'completedDate',
        headerName: 'Completed Date',
        type: 'dateTime',
        width: 180,
        valueFormatter: (params: Date) => new Date(params).toLocaleString()
    },
    {
        field: 'createdBy',
        headerName: 'Created By',
        width: 160
    },
    {
        field: 'createdDate',
        headerName: 'Created Date',
        type: 'dateTime',
        width: 180,
        valueFormatter: (params: Date) => new Date(params).toLocaleString()
    },
    {
        field: 'updatedBy',
        headerName: 'Updated By',
        width: 160
    },
    {
        field: 'updatedDate',
        headerName: 'Updated Date',
        type: 'dateTime',
        width: 180,
        valueFormatter: (params: Date) => new Date(params).toLocaleString()
    },
];

function ChoreGrid() {
    const [tableData, setTableData] = useState<Chore[]>();

    useEffect(() => {
        populateChoreData();
    }, []);

    const contents = tableData === undefined
        ? <p>No data returned.</p>
        : <div style={{ height: 700, width: '100%' }}>
            <DataGrid
                rows={tableData}
                columns={columns}
                checkboxSelection
            />
        </div>

    return (
        <div>
            {contents}
        </div>
        
    );

    async function populateChoreData() {
        const response = await fetch('chore');
        const data = await response.json();
        setTableData(data);
    }
}

export default ChoreGrid;



//const contents = forecasts === undefined
//    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//    : <table className="table table-striped" aria-labelledby="tabelLabel">
//        <thead>
//            <tr>
//                <th>Date</th>
//                <th>Temp. (C)</th>
//                <th>Temp. (F)</th>
//                <th>Summary</th>
//            </tr>
//        </thead>
//        <tbody>
//            {forecasts.map(forecast =>
//                <tr key={forecast.date}>
//                    <td>{forecast.date}</td>
//                    <td>{forecast.temperatureC}</td>
//                    <td>{forecast.temperatureF}</td>
//                    <td>{forecast.summary}</td>
//                </tr>
//            )}
//        </tbody>
//    </table>;

//return (
//    <div>
//        <h1 id="tabelLabel">Weather forecast</h1>
//        <p>This component demonstrates fetching data from the server.</p>
//        {contents}
//    </div>
//);

//async function populateWeatherData() {
//    const response = await fetch('weatherforecast');
//    const data = await response.json();
//    setForecasts(data);
//}