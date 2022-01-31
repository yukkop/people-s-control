import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { useState } from 'react';
import { Button, TouchableHighlight } from 'react-native'

import Home from './screens/Home';
import Users from './screens/Users';

import { screens } from './resources.json';


const Stack = createNativeStackNavigator();

export default function Navigation() {
    return (
        <NavigationContainer >
            <Stack.Navigator>
                <Stack.Screen
                    name={screens.home.path}
                    component={Home}

                    options={{
                    }}
                />
                <Stack.Screen
                    name={screens.users.path}
                    component={Users}

                    options={{
                    }}
                />
            </Stack.Navigator>
        </NavigationContainer>
    );
}