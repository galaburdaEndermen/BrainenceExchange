import styles from './ExchangerStyle.module.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import 'antd/dist/antd.css';
import { Select } from 'antd';
import { InputNumber } from 'antd';
import { Button } from 'antd';
import {
    SwapOutlined,
} from '@ant-design/icons';

const { Option } = Select;

const Exchanger = () => {

    const [availableCurrency, setAvailableCurrency] = useState([]);
    const [from, setFrom] = useState("USD");
    const [to, setTo] = useState("USD");
    const [amount, setAmount] = useState();
    const [result, setResult] = useState();


    function onAmountChange(value) {
        setAmount(value);
    }

    function onFromChange(value) {
        setFrom(value);
    }
    function onToChange(value) {
        setTo(value);
    }

    function onSwap() {
        let tmp = from;
        setFrom(to);
        setTo(tmp);
        // debugger;


        if (amount && result) {
            tmp = amount;
            setAmount(result);
            setResult(tmp);
        }
        else if (amount && !result) {
            setAmount();
        }
        else if (!amount && result) {
            // debugger;
            // setAmount(result);
            // setResult();

            tmp = amount;
            setAmount(result);
            setResult(tmp);
        }
    }
    function onExchange() {
        console.log('onExchange');
        axios.get("https://localhost:5001/api/Exchange", {
            params: {
                "FromCurrencyCode": from,
                "Amount": amount,
                "ToCurrencyCode": to,
            }
        }).then(res => {
            console.log(res.data);
            // debugger;


            setResult(res.data.toFixed(2));
        });
    }

    useEffect(() => {
        axios.get("https://localhost:5001/api/Info/AvailableCurrency").then(res => {
            setAvailableCurrency(res.data);
        });
    }, [])

    return (
        <>
            <div className={styles.inputs}>
                <div className={styles.inputs}>
                    <InputNumber min={0.01} step={0.01} onChange={onAmountChange} className={styles.input} value={amount} />
                    <Select onChange={onFromChange} style={{ width: 120 }} value={from} className={styles.input}>

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

                <SwapOutlined className={styles.icon} onClick={onSwap} />

                <div className={styles.inputs}>
                    <Select onChange={onToChange} style={{ width: 120 }} value={to} className={styles.input}>

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
                    <InputNumber style={{ minWidth: 120 }} min={0.01} step={0.01} className={styles.input} disabled value={result} />

                </div>

                <Button type="primary" className={styles.input} onClick={onExchange}>Exchange</Button>
            </div>
        </>
    );
}

export default Exchanger;