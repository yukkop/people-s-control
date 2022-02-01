import { StatusBar } from 'expo-status-bar';
import React, { useState, useLayoutEffect } from 'react';
import { FlatList, StyleSheet, Text, TouchableHighlight, View } from 'react-native';

import { home, colors, screens } from './../resources.json'
import { gStyles } from './../Styles';
import { api } from './../API'

export type User = {
    name: string,
    surname: string,
    patronymic: string,
    phoneNumber: string,
    emailAddress: string,
    districtId: number,
    districtName: string,
    cityId: number,
    cityName: string,
    notifyByEmail: boolean,
    notifyBySMS: boolean
}


export default function Users({ navigation }: any) {

    const [users, setUsers] = useState(api<User>("https://194.28.61.185:44373/api/user/Authorization", 'GET', 'admin', 'B2ling54B2ling3rPL292'))

    const renderUser = ({ item }: any) => (
        <TouchableHighlight>
            <Text style={[gStyles.titleText, { color: "#ffffff" }]}>{item.name}</Text>
        </TouchableHighlight>
    )

    return (
        <View>
            {/*<FlatList
                data={users}
                renderItem={renderUser}
                keyExtractor={item => item.id}
            />*/}
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'center',
    },
});
