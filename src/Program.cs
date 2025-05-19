using System.Diagnostics.Contracts;
using DxLibDLL;

class Program
{

    static void Main()
    {
        InputState GetCurrentInput() => new InputState
        {
            Jump = DX.CheckHitKey(DX.KEY_INPUT_UP) == 1,
            Right = DX.CheckHitKey(DX.KEY_INPUT_RIGHT) == 1,
            Left = DX.CheckHitKey(DX.KEY_INPUT_LEFT) == 1
        };

        public void Update()
        {
          InputState input = GetCurrentInput();
        }

    struct InputState
    {
        public bool Jump;
        public bool Right;
        public bool Left;
    }
        // ウィンドウモードで起動するように設定
        DX.ChangeWindowMode(DX.TRUE);

        // Dxlib の初期化
        DX.DxLib_Init();
        // 描画先を裏画面に設定
        DX.SetDrawScreen(DX.DX_SCREEN_BACK);

        // メインループ
        while (DX.ProcessMessage() == 0)
        {
            // 画面をクリア
            DX.ClearDrawScreen();
            // 文字を描画
            DX.DrawString(100, 100, "Hello World", DX.GetColor(255, 255, 255));
            // 裏画面の内容を表画面に反映
            DX.ScreenFlip();
        }

        // Dxlib の終了処理
        DX.DxLib_End();
    }
}
