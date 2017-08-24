/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import ImageGif from './Image.js';

import {
  AppRegistry,
  StyleSheet,
  Text,
  View,
  Button
  } from 'react-native';

var NativeEventEmitter = require('NativeEventEmitter');
var FilePickerModule = require('NativeModules').FilePickerModule;
var FilePickerEventEmitter = new NativeEventEmitter(FilePickerModule);

class uwpreactnativesample extends Component {
    constructor(props) {
        super(props);
        this.onOpenFile = this.onOpenFile.bind(this);
    }

    componentWillMount() {
        FilePickerEventEmitter.addListener(
          'openFile',
          ev => {
              alert(ev.status);
          }
        );
    }    

    openFile(e) {
        alert(e.data);
    }

    onOpenFile() {        
        FilePickerModule.openFile();
    }

    render() {
        return (
          <View style={styles.container}>
            <Text style={styles.welcome}>
              Welcome to React Native!
            </Text>
        
            <ImageGif source={{ uri: 'ms-appx:///Assets/meow.gif'}} style={{width: 600, height: 400}} />

            <Button
                onPress={this.onOpenFile}
                title="Open File"
                color="#841584"
              />

          </View>
        );
    }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

AppRegistry.registerComponent('uwpreactnativesample', () => uwpreactnativesample);