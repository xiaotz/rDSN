/**
 * Autogenerated by Thrift Compiler (@PACKAGE_VERSION@)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace dsn.app.search
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Caption : TBase
  {
    private DocId _DocIdentifier;
    private string _Title;
    private string _CaptionHtml;

    public DocId DocIdentifier
    {
      get
      {
        return _DocIdentifier;
      }
      set
      {
        __isset.DocIdentifier = true;
        this._DocIdentifier = value;
      }
    }

    public string Title
    {
      get
      {
        return _Title;
      }
      set
      {
        __isset.Title = true;
        this._Title = value;
      }
    }

    public string CaptionHtml
    {
      get
      {
        return _CaptionHtml;
      }
      set
      {
        __isset.CaptionHtml = true;
        this._CaptionHtml = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool DocIdentifier;
      public bool Title;
      public bool CaptionHtml;
    }

    public Caption() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Struct) {
              DocIdentifier = new DocId();
              DocIdentifier.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Title = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.String) {
              CaptionHtml = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Caption");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (DocIdentifier != null && __isset.DocIdentifier) {
        field.Name = "DocIdentifier";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        DocIdentifier.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Title != null && __isset.Title) {
        field.Name = "Title";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Title);
        oprot.WriteFieldEnd();
      }
      if (CaptionHtml != null && __isset.CaptionHtml) {
        field.Name = "CaptionHtml";
        field.Type = TType.String;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(CaptionHtml);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Caption(");
      bool __first = true;
      if (DocIdentifier != null && __isset.DocIdentifier) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DocIdentifier: ");
        __sb.Append(DocIdentifier== null ? "<null>" : DocIdentifier.ToString());
      }
      if (Title != null && __isset.Title) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Title: ");
        __sb.Append(Title);
      }
      if (CaptionHtml != null && __isset.CaptionHtml) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CaptionHtml: ");
        __sb.Append(CaptionHtml);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
