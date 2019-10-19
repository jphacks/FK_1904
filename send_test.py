# https://hook.integromat.com/sfvg9muq0dxm4yfgv1ixd2t65wnt6f9y

import requests
response = requests.post('https://hook.integromat.com/sfvg9muq0dxm4yfgv1ixd2t65wnt6f9y', data={'key': 'contents'})
print(response.status_code)    # HTTPのステータスコード取得
print(response.text)    # レスポンスのHTMLを文字列で取得
