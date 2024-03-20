import React, { useState, useEffect } from 'react'
import { DataGrid } from '@mui/x-data-grid'

const columns = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'name', headerName: 'Name', width: 80 },
    { field: 'description', headerName: 'Description', width: 130 },
    { field: 'completedBy', headerName: 'Completed By', width: 130 },
    {
      field: 'completedDate',
      headerName: 'Completed Date',
      type: 'dateTime',
      width: 180,
      valueFormatter: (params) => new Date(params?.value).toLocaleString()
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
      valueFormatter: (params) => new Date(params?.value).toLocaleString()
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
      valueFormatter: (params) => new Date(params?.value).toLocaleString()
    },
  ];

const ChoreGrid = () => {
  const [tableData, setTableData] = useState([]);
  useEffect(() => {
    fetch("http://localhost:5259/Chores")
      .then((response) => response.json())
      .then((response) => setTableData(response));
  }, []);

  console.log(tableData);

  return (
      <div style={{ height: 700, width: '100%' }}>
          <DataGrid
              rows={tableData}
              columns={columns}
              pageSize={12}
              checkboxSelection
          />
      </div>
  );
};

export default ChoreGrid