import styles from './HistoryPageStyle.module.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'antd/dist/antd.css';
import { Pagination } from 'antd';
import { Select } from 'antd';
import { Switch } from 'antd';
import { DatePicker } from 'antd';
import { Table, Space } from 'antd';
const { Option } = Select;
const { Column, ColumnGroup } = Table;
const { RangePicker } = DatePicker;

const DefaultPageSize = 10;

const HistoryPage = () => {
    const [entries, setEntries] = useState([]);
    const [page, setPage] = useState(1);
    const [count, setСount] = useState(0);
    const [availableCurrency, setAvailableCurrency] = useState([]);
    const [selectedFrom, setSelectedFrom] = useState([]);
    const [selectedTo, setSelectedTo] = useState([]);
    const [orderColumn, setOrderColumn] = useState("Date");
    const [descending, setDescending] = useState(false);
    const [startDate, setStartDate] = useState();
    const [endDate, setEndDate] = useState();

    var qs = require('qs');

    function onFromChange(value) {
        console.log(value);
        setSelectedFrom(value);
    }

    function getEntries() {
        setPage(1);
        // debugger;
        axios.get("https://localhost:5001/api/History", {
            params: {
                "FromCurrencyCodes": [...selectedFrom],
                "OrderColumnName": orderColumn,
                "ToCurrencyCodes": [...selectedTo],
                "IsDescending": descending,
                "PageSize": DefaultPageSize,
                "PageNumber": page,
                "StartDate": startDate,
                "EndDate": endDate,
            },
            paramsSerializer: params => {
                return qs.stringify(params)
            }
        }).then(res => {
            setEntries(res.data.entries);
            setСount(res.data.count);
        });
    }

    useEffect(() => {
        getEntries()
    }, [selectedFrom, selectedTo, startDate, endDate, descending, orderColumn]);


    function onDatesChange(value, dateString) {
        // console.log('Selected Time: ', value);
        // console.log('Formatted Selected Time: ', dateString);
        // console.log('Formatted Selected Time: ', value[0].toJSON());
        // console.log('Formatted Selected Time: ', value[1].toJSON());
        // debugger;
        if (value) {
            setStartDate(value[0].toJSON());
            setEndDate(value[1].toJSON());
        }
        else {
            setStartDate();
            setEndDate();
        }
    }

    function onToChange(value) {
        console.log(value);
        setSelectedTo(value);
    }

    function handleDescendingChange(value) {
        setDescending(value);
    }

    function handleColumnChange(value) {
        setOrderColumn(value);
    }

    useEffect(() => {
        axios.get("https://localhost:5001/api/Info/AvailableCurrency").then(res => {
            setAvailableCurrency(res.data);
            setSelectedFrom(res.data);
            setSelectedTo(res.data);
        });
    }, []);

    function handlePageChange(page, pageSize) {
        setPage(page);

        axios.get("https://localhost:5001/api/History", {
            params: {
                "FromCurrencyCodes": [...selectedFrom],
                "OrderColumnName": orderColumn,
                "ToCurrencyCodes": [...selectedTo],
                "IsDescending": descending,
                "PageSize": DefaultPageSize,
                "PageNumber": page,
                "StartDate": startDate,
                "EndDate": endDate,
            },
            paramsSerializer: params => {
                return qs.stringify(params)
            }
        }).then(res => {
            setEntries(res.data.entries);
            setСount(res.data.count);
        });
    }

    useEffect(() => {
        if (availableCurrency.length) {
            axios.get("https://localhost:5001/api/History", {
                params: {
                    "FromCurrencyCodes": [...availableCurrency],
                    "OrderColumnName": "Date",
                    "ToCurrencyCodes": [...availableCurrency],
                    "IsDescending": false,
                    "PageSize": DefaultPageSize,
                    "PageNumber": 1,
                },
                paramsSerializer: params => {
                    return qs.stringify(params)
                }
            }).then(res => {
                setEntries(res.data.entries);
                setСount(res.data.count);
            });
        }

    }, [availableCurrency]);



    return (
        <>

            <div className={styles.container}>
                <h4>From</h4>
                <h4>To</h4>
            </div>

            <div className={styles.container}>
                <Select
                    mode="multiple"
                    allowClear
                    style={{ width: '50%' }}
                    placeholder="Please select"
                    value={selectedFrom}
                    onChange={onFromChange}
                >
                    {availableCurrency.map(currency =>
                        <Option
                            key={currency}
                            value={currency}
                        >
                            <img src={`https://localhost:5001/api/Pictures/Get/${currency}`} style={{ width: 24, height: 24 }} /> {currency}
                        </Option>
                    )
                    }
                </Select>



                <Select
                    mode="multiple"
                    allowClear
                    style={{ width: '50%' }}
                    placeholder="Please select"
                    value={selectedTo}
                    onChange={onToChange}
                >
                    {availableCurrency.map(currency =>
                        <Option
                            key={currency}
                            value={currency}
                        >
                            <img src={`https://localhost:5001/api/Pictures/Get/${currency}`} style={{ width: 24, height: 24 }} /> {currency}
                        </Option>
                    )
                    }
                </Select>
            </div>


            <div className={styles.container}>

                <Select value={orderColumn} style={{ width: 200 }} onChange={handleColumnChange}>
                    <Option value="FromCurrencyCode">From currency code</Option>
                    <Option value="FromAmount">From amount</Option>
                    <Option value="ToCurrencyCode">To currency code</Option>
                    <Option value="ToAmount">To amount</Option>
                    <Option value="Date">Date</Option>
                </Select>
                <Switch checkedChildren="Descending" unCheckedChildren="Ascend" onChange={handleDescendingChange} checked={descending} />
                <RangePicker showTime onChange={onDatesChange} />
            </div>



            <Table dataSource={entries} pagination={false}>
                <ColumnGroup title="Info">
                    <Column title="Id" dataIndex="id" key="id" />
                    <Column title="Date" dataIndex="date" key="date"
                        render={date => (
                            <>
                                {new Date(date).toLocaleString()}
                            </>
                        )}
                    />
                </ColumnGroup>

                <Column title="From currency" dataIndex="fromCurrencyCode" key="fromCurrencyCode"
                    render={code => (
                        <>
                            <img src={`https://localhost:5001/api/Pictures/Get/${code}`} style={{ width: 24, height: 24 }} /> {code}
                        </>
                    )}
                />
                <Column title="From amount" dataIndex="fromAmount" key="fromAmount" />

                <Column title="To currency" dataIndex="toCurrencyCode" key="toCurrencyCode"
                    render={code => (
                        <>
                            <img src={`https://localhost:5001/api/Pictures/Get/${code}`} style={{ width: 24, height: 24 }} /> {code}
                        </>
                    )}
                />
                <Column title="To amount" dataIndex="toAmount" key="toAmount" />





            </Table>

            <Pagination defaultCurrent={1} current={page} total={count} pageSize={DefaultPageSize} showSizeChanger={false} onChange={handlePageChange} />
        </>
    );
}

export default HistoryPage;